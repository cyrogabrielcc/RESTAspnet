using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RESTAspnet.models;

namespace RESTAspnet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;
        
        public Person Create(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i<8; i++){
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        

        public Person FindById(long id)
        {
            return new Person 
            {
                Id = 1,
                FirstName = "Cyro",
                LastName = "Cunha",
                Address = "RJ",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person 
            {
                Id = IncrementGetAndAdd(),
                FirstName = "FirstName" + i,
                LastName = "LastName" + i,
                Address = "Address" + i,
                Gender = "Male"
            };
        }

        private long IncrementGetAndAdd()
        {
            return Interlocked.Increment(ref count);
        }
    }
}