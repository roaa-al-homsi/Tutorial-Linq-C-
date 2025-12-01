namespace Shared
{
    public class Choice
    {
        public int Order { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = obj as Choice;
            if (other is null)
            {
                return false;
            }

            return this.Order.Equals(other.Order)
                && this.Description.Equals(other.Description);

        }

        public override int GetHashCode()
        {
            int hash = 17;
            //check null
            hash = hash * 23 + Order.GetHashCode();
            hash = hash * 23 + Description.GetHashCode();
            return hash;
        }
    }
}
