namespace Source.Test
{
    class Rent
    {
        public string TenantName { get; set; }
        public string TenantEmail { get; set; }

        public override string ToString()
        {
            return "Name: " + TenantName + ", Email: " + TenantEmail;
        }
    }
}
