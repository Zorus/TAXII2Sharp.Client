
# TAXII2Sharp.Client
[![NuGet](https://img.shields.io/nuget/v/TAXII2Sharp.Client)](https://www.nuget.org/packages/TAXII2Sharp.Client/)

TAXII2Sharp.Client is a C# .NET Standard implementation of the TAXII2 specifications for retrieving STIX structured data from a TAXII Endpoint.

For more information on the TAXII Specifications, please see the References section below.

For more information on the STIX specifications, please see the References section below.


## Usage

```C#
using System;
using System.Collections.Generic;
// Please note that the client version to be imported is dependent on the TAXII Standard version run by the server
using TAXIISharp2.Client.V20;

...

// Create a server
Server endpoint = new Server("https://somesite.org/taxii");

// Get a list of the APIRoot endpoints provided by that server
List<APIRoots> APIRoots = endpoint.GetAPIRoots();

// Iterate over the APIRoot objects
foreach (APIRoot root in APIRoots)
{
    // Iterate over the Collection hosted at that APIRoot 
    foreach (Collection collection in root.Collections)
    {
        // Get the STIX objects that the collection contains
        var Objects = collection.GetObjects();
        Console.WriteLine("Total objects in collection: {0}", Objects.Objects.Length);
    }
}
```
For additional information, please see the example included in the project

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


## References
[TAXII 2.0 Specification](https://docs.oasis-open.org/cti/taxii/v2.0/taxii-v2.0.pdf)

[TAXII 2.1 Specification](https://docs.oasis-open.org/cti/taxii/v2.1/taxii-v2.1.pdf)

[STIX Specification](https://www.oasis-open.org/committees/download.php/58538/STIX2.0-Draft1-Core.pdf)

## License
[GNU Lesser General Public License v2.1](https://choosealicense.com/licenses/lgpl-2.1/)
