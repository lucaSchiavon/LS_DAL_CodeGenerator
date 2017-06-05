using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CodeGeneratorSln
{
     // delegates used to call MainForm functions from
  //  worker thread
      public delegate void DelegateAddString(String s);
      public delegate void DelegateThreadFinished();

    


    public partial class testForm : Form
    {
    // worker thread
    Thread m_WorkerThread;

    // events used to stop worker thread
    ManualResetEvent m_EventStopThread;
    ManualResetEvent m_EventThreadStopped;

    // Delegate instances used to call user interface 
    // functions from worker thread:
    public DelegateAddString m_DelegateAddString;
    public DelegateThreadFinished m_DelegateThreadFinished;


    private System.ComponentModel.BackgroundWorker backgroundWorker1;

        public testForm()
        {
            InitializeComponent();
          //  // initialize delegates
            m_DelegateAddString = new DelegateAddString(this.AddString);
            m_DelegateThreadFinished = new DelegateThreadFinished(this.ThreadFinished);

            // initialize events
            m_EventStopThread = new ManualResetEvent(false);
            m_EventThreadStopped = new ManualResetEvent(false);




        }


        private void btnWrite_Click(object sender, EventArgs e)
        {


             // reset events
              m_EventStopThread.Reset();
              m_EventThreadStopped.Reset();

              // create worker thread instance
              m_WorkerThread = new Thread(new ThreadStart(this.WorkerThreadFunction));

              m_WorkerThread.Name = "Worker Thread Sample"; // looks nice 
                                              // in Output window

              m_WorkerThread.Start();
        }

            // Worker thread function.
        // Called indirectly from btnStartThread_Click
        private void WorkerThreadFunction()
        {
          LongProcess longProcess;

          longProcess = new LongProcess(m_EventStopThread, m_EventThreadStopped, this);

          longProcess.Run();
        }

        // Add string to list box.
        // Called from worker thread using delegate and Control.Invoke
        private void AddString(String s)
        {
            listBox1.Items.Add(s);
        }

        // Set initial state of controls.
        // Called from worker thread using delegate and Control.Invoke
        private void ThreadFinished()
        {
            btnWrite.Enabled = true;
            btnStopWrite.Enabled = false;
        }

        

        private void btnStopWrite_Click(object sender, EventArgs e)
        {
            if (m_WorkerThread != null &&
            m_WorkerThread.IsAlive)  // thread is active
            {
                // set event "Stop"
                m_EventStopThread.Set();

                // wait when thread  will stop or finish
                while (m_WorkerThread.IsAlive)
                {
                    // We cannot use here infinite wait because our thread
                    // makes syncronous calls to main form, this will cause 
                    // deadlock.
                    // Instead of this we wait for event some appropriate time
                    // (and by the way give time to worker thread) and
                    // process events. These events may contain Invoke calls.
                    if (WaitHandle.WaitAll(
                        (new ManualResetEvent[] { m_EventThreadStopped }),
                        100,
                        true))
                    {
                        break;
                    }

                    Application.DoEvents();
                }
            }

        }
    }

    public class LongProcess
    {
        #region Members

        // Main thread sets this event to stop worker thread:
        ManualResetEvent m_EventStop;

        // Worker thread sets this event when it is stopped:
        ManualResetEvent m_EventStopped;

        // Reference to main form used to make syncronous user interface calls:
        testForm m_form;

        #endregion

        #region Functions

        public LongProcess(ManualResetEvent eventStop,
                           ManualResetEvent eventStopped,
                           testForm form)
        {
            m_EventStop = eventStop;
            m_EventStopped = eventStopped;
            m_form = form;
        }

        // Function runs in worker thread and emulates long process.
        public void Run()
        {
            int i;
            String s;

            for (i = 1; i <= 10000; i++)
            {
                // make step
                s = "Step number " + i.ToString() + " executed";

                Thread.Sleep(50);

                // Make synchronous call to main form.
                // MainForm.AddString function runs in main thread.
                // To make asynchronous call use BeginInvoke
                m_form.Invoke(m_form.m_DelegateAddString, new Object[] { s });


                // check if thread is cancelled
                if (m_EventStop.WaitOne(0, true))
                {
                    // clean-up operations may be placed here
                    // ...

                    // inform main thread that this thread stopped
                    m_EventStopped.Set();

                    return;
                }
            }

            // Make asynchronous call to main form
            // to inform it that thread finished
            m_form.Invoke(m_form.m_DelegateThreadFinished, null);
        }

        #endregion
    }

}
