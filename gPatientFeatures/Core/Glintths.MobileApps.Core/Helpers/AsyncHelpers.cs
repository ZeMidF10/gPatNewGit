using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.MobileApps.Core.ServiceAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.Helpers
{
    public static class AsyncHelpers
    {
        /// <summary>
        /// Execute's an async Task<T> method which has a void return value synchronously
        /// </summary>
        /// <param name="task">Task<T> method to execute</param>
        public static void RunSync(Func<Task> task)
        {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            synch.Post(async _ =>
            {
                try
                {
                    await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();

            SynchronizationContext.SetSynchronizationContext(oldContext);
        }

        /// <summary>
        /// Execute's an async Task<T> method which has a T return type synchronously
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="task">Task<T> method to execute</param>
        /// <returns></returns>
        public static T RunSync<T>(Func<Task<T>> task)
        {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            T ret = default(T);
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret;
        }


        /// <summary>
        /// GetSpecialtyByID -> Sincrono
        /// Usado para ir buscar a especialidade no caso do utilizador selecionar primeiro o ato médico
        /// </summary>
        /// <param name="task"></param>
        /// <returns>Returna uma especialidade</returns>
        public static ServiceReturn<Specialty> RunSync(Func<Task<ServiceReturn<Specialty>>> task)
        {

            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "");
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Erro ao obter a especialidade");
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "");
            #endregion

            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            ServiceReturn<Specialty> ret = default(ServiceReturn<Specialty>);
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret;//ServiceReturnHandling.BuildSuccessCallReturn<Specialty>(ret, uiMessages);
        }


        /// <summary>
        /// Usado para o login
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="task">Task<T> method to execute</param>
        /// <returns></returns>
        public static ServiceReturn<bool> RunSync(Func<Task<bool>> task)
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "");
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Erro a fazer login");
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "");
            #endregion

            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            bool ret = false;
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ServiceReturnHandling.BuildSuccessCallReturn<bool>(ret, uiMessages);
        }

        public static ServiceReturn<List<FreeTimeSlot>> RunSync(Func<Task<ServiceReturn<List<FreeTimeSlot>>>> task)
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "");
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Erro ao obter a lista de vagas");
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "");
            #endregion

            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            ServiceReturn<List<FreeTimeSlot>> ret = default(ServiceReturn<List<FreeTimeSlot>>);
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret;//ServiceReturnHandling.BuildSuccessCallReturn<List<FreeTimeSlot>>(ret, uiMessages);
        }

        public static ServiceReturn<HumanResource> RunSync(Func<Task<ServiceReturn<HumanResource>>> task)
        {

            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "");
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Erro ao obter o médico");
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "");
            #endregion

            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            ServiceReturn<HumanResource> ret = default(ServiceReturn<HumanResource>);
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret; // ServiceReturnHandling.BuildSuccessCallReturn<HumanResource>(ret, uiMessages);
        }

        public static ServiceReturn<List<HumanResource>> RunSync(Func<Task<ServiceReturn<List<HumanResource>>>> task)
        {

            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "");
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Erro ao obter a lista de médicos");
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "");
            #endregion

            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            ServiceReturn<List<HumanResource>>  ret = default(ServiceReturn<List<HumanResource>> );
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret; //ServiceReturnHandling.BuildSuccessCallReturn<List<HumanResource>>(ret, uiMessages);
        }

        public static ServiceReturn<List<ScheduledAppointment>> RunSync(Func<Task<List<ScheduledAppointment>>> task)
        {

            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "");
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Erro ao concluir a marcação");
            if (!string.IsNullOrEmpty(""))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "");
            #endregion

            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            List<ScheduledAppointment> ret = default(List<ScheduledAppointment>);
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ServiceReturnHandling.BuildSuccessCallReturn<List<ScheduledAppointment>>(ret, uiMessages);
        }

        private class ExclusiveSynchronizationContext : SynchronizationContext
        {
            private bool done;
            public Exception InnerException { get; set; }
            readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
            readonly Queue<Tuple<SendOrPostCallback, object>> items =
                new Queue<Tuple<SendOrPostCallback, object>>();

            public override void Send(SendOrPostCallback d, object state)
            {
                throw new NotSupportedException("We cannot send to our same thread");
            }

            public override void Post(SendOrPostCallback d, object state)
            {
                lock (items)
                {
                    items.Enqueue(Tuple.Create(d, state));
                }
                workItemsWaiting.Set();
            }

            public void EndMessageLoop()
            {
                Post(_ => done = true, null);
            }

            public void BeginMessageLoop()
            {
                while (!done)
                {
                    Tuple<SendOrPostCallback, object> task = null;
                    lock (items)
                    {
                        if (items.Count > 0)
                        {
                            task = items.Dequeue();
                        }
                    }
                    if (task != null)
                    {
                        task.Item1(task.Item2);
                        if (InnerException != null) // the method threw an exeption
                        {
                            throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
                        }
                    }
                    else
                    {
                        workItemsWaiting.WaitOne();
                    }
                }
            }

            public override SynchronizationContext CreateCopy()
            {
                return this;
            }
        }
    }
}
