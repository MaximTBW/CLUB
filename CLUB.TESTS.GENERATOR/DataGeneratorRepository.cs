using CLUB.Context.CONTRACTS.Enums;
using CLUB.Context.CONTRACTS.Models;

namespace CLUB.TESTS.GENERATOR
{
    public class DataGeneratorRepository
    {
        static public Client Client(Action<Client>? settings = null)
        {
            var result = new Client
            {
                Surname = $"Surname{Guid.NewGuid():N}",
                Name = $"Name{Guid.NewGuid():N}",
                Phone = $"Phone{Random.Shared.Next(0, 100000)}",
                Email = $"Email{Guid.NewGuid():N}@gmail.com",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }
        static public Worker Worker(Action<Worker>? settings = null)
        {
            var result = new Worker
            {
                Number = $"Num{Random.Shared.Next(0, 100000)}",
                Series = $"Ser{Random.Shared.Next(0, 100000)}",
                IssuedBy = $"IssuedBy{Guid.NewGuid():N}",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static public Component Component(Action<Component>? settings = null)
        {
            var result = new Component
            {
                Name = $"Name{Guid.NewGuid():N}",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static public Service Service(Action<Service>? settings = null)
        {
            var result = new Service
            {
                Name = $"Name{Guid.NewGuid():N}",
                Duration = Random.Shared.Next(2, 6),
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }
        static public Delivery Delivery(Action<Delivery>? settings = null)
        {
            var result = new Delivery
            {
                From = $"From{Guid.NewGuid():N}",
                To = $"To{Guid.NewGuid():N}",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static public Order Order(Action<Order>? settings = null)
        {
            var result = new Order();

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static public AccessKey AccessKey(Action<AccessKey>? settings = null)
        {
            var result = new AccessKey
            {
                Key = Guid.NewGuid(),
                Types = AccessLevelTypes.Assistant,
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }
    }
}