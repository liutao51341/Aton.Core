using System;
using System.Threading;
using System.Threading.Tasks;
using Aton.Core.Library.GenericEngine.Events;

namespace Aton.Core.Library.GenericEngine
{
    /// <summary>
    /// 引擎基类
    /// </summary>
    public class AtonGenericEngine
    {
        #region 引擎对象
         /// <summary>
        /// 执行任务
        /// </summary>
        Task task;
        /// <summary>
        /// 任务可取消控制对象
        /// </summary>
        private CancellationTokenSource cancelTokeSource;
        /// <summary>
        /// 执行体
        /// </summary>
        private Action<object> ProcContext = null;
        /// <summary>
        /// 执行体参数
        /// </summary>
        private object ProcParameter = null;
        #endregion

        #region 引擎属性
        /// <summary>
        /// 引擎名称
        /// </summary>
        public string EngineName
        {
            get;
            set;
        }
        /// <summary>
        /// 引擎状态
        /// </summary>
        public EngineStatus EngineStatus
        {
            get;
            internal set;
        }
        #endregion

        #region 触发事件
        /// <summary>
        /// 初始化完成通知事件
        /// </summary>
        public event EngineInitEventHandler AtonEngineInitEvent;
        /// <summary>
        /// 启动完成通知事件
        /// </summary>
        public event EngineStartedEventHandler AtonEngineStartedEvent;
        /// <summary>
        /// 停止通知事件
        /// </summary>
        public event EngineStoppedEventHandler AtonEngineStoppedEvent;
        /// <summary>
        /// 出现错误通知事件
        /// </summary>
        public event EngineFaultEventHandler AtonEngineFaultEvent;

        /// <summary>
        /// 触发启动完成通知事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void FireAtonEngineInitEvent(object sender, EngineInitEventArgs args)
        {
            if (AtonEngineInitEvent != null)
                AtonEngineInitEvent(sender, args);
        }
        /// <summary>
        /// 触发启动完成通知事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void FireAtonEngineStartedEvent(object sender, EngineStartedEventArgs args)
        {
            if (AtonEngineStartedEvent != null)
                AtonEngineStartedEvent(sender, args);
        }
        /// <summary>
        /// 触发停止通知事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void FireAtonEngineStoppedEvent(object sender, EngineStoppedEventArgs args)
        {
            if (AtonEngineStoppedEvent != null)
                AtonEngineStoppedEvent(sender, args);
        }
        /// <summary>
        /// 触发异常通知事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void FireAtonEngineFaultEvent(object sender, EngineFaultEventArgs args)
        {
            if (AtonEngineFaultEvent != null)
                AtonEngineFaultEvent(sender, args);
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// 设定引擎名称
        /// </summary>
        /// <param name="_engineName"></param>
        public AtonGenericEngine(string _engineName)
        {
            EngineName = _engineName;
            EngineStatus = EngineStatus.NotReady;
        }
        #endregion

        #region 初始化引擎
        /// <summary>
        /// 启动引擎
        /// </summary>
        /// <returns></returns>
        public bool LoadEngine(Action<object> procContext, object param)
        {
            if (EngineStatus != EngineStatus.Running && EngineStatus!= EngineStatus.WaitToStop)
            {
                ProcContext = procContext;
                ProcParameter = param;
                FireAtonEngineInitEvent(this, new EngineInitEventArgs(EngineName));
                EngineStatus = GenericEngine.EngineStatus.Ready;
                return true;
            }
            return false;
        }
        #endregion

        #region 启动引擎
        /// <summary>
        /// 启动引擎
        /// </summary>
        /// <returns></returns>
        public  bool StartEngine()
        {
            bool result = false;
            if (EngineStatus == EngineStatus.NotReady)
            {
                FireAtonEngineFaultEvent(this, new EngineFaultEventArgs("Engine is not ready","",EngineName));
                return result;
            }
            try
            {
                cancelTokeSource = new CancellationTokenSource();
                task = Async.LongRun(ProcContext,ProcParameter,cancelTokeSource.Token,EngineException);
                EngineStatus = EngineStatus.Running;
                FireAtonEngineStartedEvent(this, new EngineStartedEventArgs(result, EngineName));
                result = true;
            }
            catch(Exception ex)
            {
                string e = ex.StackTrace;
                result = false;
            }

            return result;
        }
        #endregion

        #region 停止引擎
        /// <summary>
        /// 停止引擎
        /// </summary>
        /// <returns></returns>
        public  bool StopEngine()
        {
            bool result = false;
            if (EngineStatus == EngineStatus.Running)
            {
                cancelTokeSource.Cancel();
                EngineStatus = EngineStatus.Stopped;
                FireAtonEngineStoppedEvent(this, new EngineStoppedEventArgs(EngineName, true, "Engine normaly Stop"));
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 引擎异常
        /// <summary>
        /// 引擎异常
        /// </summary>
        /// <param name="ex"></param>
        protected void EngineException(Exception ex)
        {
            EngineStatus = EngineStatus.Stopped;
            FireAtonEngineFaultEvent(this,new EngineFaultEventArgs (ex.Message,ex.StackTrace,EngineName));
            FireAtonEngineStoppedEvent(this,new EngineStoppedEventArgs (EngineName,true,"Engine Process Exception Stop"));
        }
        #endregion
    }
}
