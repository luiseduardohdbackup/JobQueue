using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class TaskQueue
    {
        private int idCounter;
        private List<Job> jobs;
        private Store store;
        private Dictionary<string, Task> tasks;

        public string coalesce(string FirstObject, string SecondObject)
        {
            return Util.Coalesce<string>(FirstObject, SecondObject);
        }

        public TaskQueue(string id)
        {
            // memory store
            this.jobs = new List<Job>();

            // persistent store
            this.store = store.prefix("queue" + coalesce(id, ""));
        }

        public TaskQueue()
        {
        }

        public string nextId()
        {
            return "job-" + (++idCounter) + "" + (new DateTime()).Ticks;
        }

        public Task define(string type)
        {
            var task = new Task(type);
            this.tasks[type] = task;
            return task;
        }
        public void process(Job job)
        {
            var _this = this;

            var task = this.tasks[job.type];

            Action<object> remove = (state) =>
            {
                job.off();
                _this.remove(job.id);
                if (state != null) _this.emit(state, job);
            };

            if (!(task != null))
            {
                remove(null);
                throw new Error("unknown " + job.type);
            }

            job.on("complete", () => { remove("complete"); });
            job.on("error", () => { remove("error"); });
            task.process(job);
        }

        public void emit(object state, Job job)
        {
            throw new NotImplementedException();
        }

        public TaskQueue create(string v, object data)
        {
            return this;
        }

        public void start()
        {
            var ids = this.store.get();
            Job job = new Job();
            string jobId = "";
            var i = 0;

            if ( ! (ids != null) ) return;

            // load existing jobs
            for (i = 0; i < ids.Count; i++)
            {
                jobId = ids[i];
                job = this.store.get(jobId);

                if (job != null )
                {
                    //Emitter(job);//TODO
                    this.jobs.Add(job);//this.jobs.push(job);
                }
            }

            // process jobs
            for (i = 0; i < this.jobs.Count; i++)
            {
                job = this.jobs[i];
                this.process(job);
            }
        }

        public void remove(object id)
        {
            throw new NotImplementedException();
        }

        public TaskQueue online()
        {
            return this;
        }


        public TaskQueue on(string v, Action< object> p)
        {
            return this;
        }
        public TaskQueue on(string v, Action p)
        {
            return this;
        }
    }
}
