using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class Task
    {
        public string type;
        public string name;
        public int _interval;
        public int _retry;
        public bool _online;

        public Navigator navigator;
        public int? _delay;
        public int? _timeout;
        public int? _lifetime;
        public Action<object, Action<object>> _action;

        //public Task(string type)
        //{
        //    this.type = type;
        //}

        public int? coalesce(int? a, int? b)
        {
            if (a != null)
                return a;
            else
                return b;
        }

        public Task(string name)
        {
            this.name = name;
            this._interval = Util.ms("2s");
            this._retry = 0;
            this._online = false;
        }


        public void process(Job job)
        {
            var _this = this;
            var timeout = 0;
            var death = 0;
            int? delay = 0;

            if (this._online && !navigator.onLine)
            {
                job.emit("offline");
                _this.replay(job);
                return;
            }

            // set job retry
            job.retry = coalesce(job.retry, 0) + 1;

            // get delay
            delay = (this._delay != null && job.retry == 1) ? this._delay : 0;

            setTimeout(() => {
                // check timeout
                if (_this._timeout != null)
                {
                    job.timeout = false;
                    Action markTimeout = () => {
                        job.timeout = true;
                        job.emit("timeout");
                        _this.replay(job);
                    };
                    var jobTimeout = _this._timeout;
                    timeout = setTimeout(markTimeout, jobTimeout);
                }

                // check lifetime
                if (_this._lifetime != null)
                {
                    job.death = false;
                    Action markDeath = () => {
                        job.death = true;
                        job.emit("death");
                    };
                    var jobTimeToLive = _this.timeToLive(job);
                    death = setTimeout(markDeath, jobTimeToLive);
                }

                Action<object> done = (err) => {
                    var isTimeout = job.timeout;
                    var isDeath = job.death;
                    if (isTimeout)
                    {
                        //job.emit( "error", "timeout");
                        return;
                    }
                    if (isDeath)
                    {
                        //job.emit( "error", "death");
                        return;
                    }
                    clearTimeout(timeout);
                    clearTimeout(death);
                    if (err != null)
                    {
                        job.emit("fail", err);
                        _this.replay(job);
                    }
                    else
                    {
                        job.emit("complete");
                    }
                };

                // start action
                _this._action(job, done);

            }, delay);
        }

        public Task action(Action<object, Action<object>> action)
        {
            this._action = action;//TODO
            return this;
        }

        public void replay(Job job)
        {
            var _this = this;
            var retry = coalesce(job.retry, 0);
            var canRetry = retry <= this._retry;
            var hasTimeToLive = this.timeToLive(job) > 0;
            var canReplay = canRetry && hasTimeToLive;

            if (canReplay)
            {
                Action processJob = () => {
                    _this.process(job);
                };
                setTimeout(processJob, this._interval);
            }
            else
            {
                job.emit("error");
            }
        }

        public int setTimeout(Action processJob, int interval)
        {
            throw new NotImplementedException();
        }
        public int setTimeout(Action processJob, long interval)
        {
            throw new NotImplementedException();
        }

        public Task interval(string interval)
        {
            this._interval = Util.ms(interval);
            return this;
        }

        public Task lifetime(string lifetime)
        {
            this._lifetime = Util.ms(lifetime);
            return this;
        }
        public long timeToLive(Job job)
        {
            long result = 0;
            if (!(this._lifetime != null))
            {
                return int.MaxValue;
            }
            //var currentTime = new DateTime().getTime();
            var currentTime = new Date().getTime();
            //result = Math.max(0, job.time + this._lifetime - currentTime);
            var jobExpirationTime = job.time + this._lifetime;
            result = Math.Max(0, (long)jobExpirationTime - currentTime);
            return result;
        }

        public Task retry(int retry)
        {
            this._retry = retry;
            return this;
        }

        public Task online()
        {
            this._online = true;
            return this;
        }

        public Task timeout(string timeout)
        {
            this._timeout = Util.ms(timeout);
            return this;
        }

        public Task delay(string delay)
        {
            this._delay = Util.ms(delay);
            return this;
        }

        public void clearTimeout(int timeout)
        {
            throw new NotImplementedException();
        }

        public int setTimeout(Action p, int? delay)
        {
            throw new NotImplementedException();
        }

        //private object function()
        //{
        //    throw new NotImplementedException();
        //}

        //private void replay(Job job)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
