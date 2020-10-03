using System;

namespace M4Trader.ordenes.services.Entities
{

    public class InCourseRequest
    {
        public DateTime When
        {
            get;
            protected set;
        }

        public Guid Id
        {
            get;
            protected set;
        }


        public InCourseRequest()
        {
            Id = Guid.NewGuid();
            When = DateTime.Now;
        }

        public static InCourseRequest New()
        {
            var r = new InCourseRequest();
            return r;
        }

        public long? Identity_rid
        {
            get;
            set;
        }

        public Guid SecurityTokenId { get; set; }
        public string Origen { get; set; }
        public string Agencia { get; set; }
    }
}
