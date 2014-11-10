namespace Fluent.NHibernate.Examples.Models
{
    public class PayloadCollectionItem : AbstractCollectionItem<PayloadCollectionItem, PayloadCollection>
    {
        public virtual Payload Payload { get; set; }

        public PayloadCollectionItem()
        {
            Initialize();
        }

        private void Initialize()
        {
            Payload = new Payload();
        }
    }
}
