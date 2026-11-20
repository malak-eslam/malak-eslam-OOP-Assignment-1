**1. Why is a single 20-parameter constructor a practical problem?**

It is hard to read and use, and it is easy to swap parameters with the same data type. Adding optional properties also makes the constructor harder to maintain.

**2. Is it only a long constructor problem?**

No. The deeper problem is that the Invoice class contains many loosely related properties with different responsibilities, making it harder to understand and maintain.

# Task 3.3 – Composed Builders

## Why is the composed version better than a single large builder?

The composed version is better because it separates the responsibilities into smaller builders.

* `AddressBuilder` is responsible only for creating an `Address`.
* The same `AddressBuilder` can be reused for both billing and shipping addresses.
* `OrderBuilder` is responsible for creating the order and payment information.
* Each builder can validate its own data independently.
* The final `InvoiceBuilder` combines the smaller objects into the complete `Invoice`.

This makes the code easier to read, maintain, validate, and reuse compared to having one large builder with many methods for all invoice properties.
