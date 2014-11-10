namespace Fluent.NHibernate.Examples.Models
{
    public class Payload : DomainModel
    {
        public virtual string Name { get; set; }

        public virtual int Value { get; set; }

        public Payload()
        {
            Initialize();
        }

        private void Initialize()
        {
            Name = string.Empty;
            Value = 0;
        }
    }
}
