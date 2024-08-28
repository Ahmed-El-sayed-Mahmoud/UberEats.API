using System;
using System.Collections.Generic;


namespace UberEats.Domain.Exceptions
{
    public  class ConflictException:Exception
    {
        public string ResourceName { get; }
        public string ResourceIdentifier { get; }

        public ConflictException(string resourceName, string resourceIdentifier)
            : base($"A {resourceName} with id: {resourceIdentifier} already exists")
        {
            ResourceName = resourceName;
            ResourceIdentifier = resourceIdentifier;
        }
    }
}
