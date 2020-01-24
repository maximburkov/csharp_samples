using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Helpers.AsyncAwait
{
    public static class AsyncAwaitTest
    {
        [CompilerGenerated]
        private sealed class TestAsyncd__1 : IAsyncStateMachine
        {
            public int state__1;
            public AsyncTaskMethodBuilder<int> t__builder;
            private int res5__1;
            private TaskAwaiter u__1;

            public void MoveNext()
            {
                int num = state__1;
                int result;

                try
                {
                    TaskAwaiter awaiter;
                    if (num != 0)
                    {

                        res5__1 = 42;
                        awaiter = Task.Delay(1000).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = (state__1 = 0);

                            u__1 = awaiter;

                            TestAsyncd__1 stateMachine = this;

                            t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = u__1;

                        u__1 = default(TaskAwaiter);
                        num = (state__1 = -1);
                    }
                    awaiter.GetResult();
                    result = res5__1;
                }
                catch (Exception exception)
                {

                    state__1 = -2;
                    t__builder.SetException(exception);
                    return;
                }

                state__1 = -2;
                t__builder.SetResult(result);
            }

            void IAsyncStateMachine.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                this.MoveNext();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
                this.SetStateMachine(stateMachine);
            }
        }

        [AsyncStateMachine(typeof(TestAsyncd__1))]
        [DebuggerStepThrough]
        public static Task<int> TestAsync()
        {

            TestAsyncd__1 stateMachine = new TestAsyncd__1();
            stateMachine.t__builder = AsyncTaskMethodBuilder<int>.Create();
            stateMachine.state__1 = -1;
            AsyncTaskMethodBuilder<int> t__builder = stateMachine.t__builder;

            t__builder.Start(ref stateMachine);
            return stateMachine.t__builder.Task;
        }
    }
}