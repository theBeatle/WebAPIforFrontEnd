using System.Data.Entity;

namespace ProjectAPI
{
    internal class CustomInit<T> : DropCreateDatabaseIfModelChanges<Factory>
    {
        protected override void Seed(Factory context)
        {
            base.Seed(context);
            context.Workers.Add(new Worker
            {
                FirstName = "Petro",
                LastName = "Petrenko",
                Gender = "Montagnik",
                Salary = 9999m,
                Address = "Rivne, Soborna str., 56"
            });
            context.Workers.Add(new Worker
            {
                FirstName = "Ivan",
                LastName = "Ivaneko",
                Gender = "male",
                Salary = 19999m,
                Address = "Lutsk, Rivnenka str., 112"
            });
            context.Workers.Add(new Worker
            {
                FirstName = "Vitalik",
                LastName = "Klichko",
                Gender = "Mer",
                Salary = 1005000m,
                Address = "Kyiv, Nezalegnosti midan, 1"
            });
            context.SaveChanges();
        }

    }
}