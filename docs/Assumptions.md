# Assumptions

To keep the assignment focused on the core booking workflow, the following assumptions are made.

## General

- Concert tickets follow the **General Admission** model (tickets are sold by category without assigned seats).
- Assigned seating is out of scope because the assignment focuses on flash-sale booking and overselling prevention.
- Authentication and Authorization are assumed to be handled by an external identity provider and are not implemented.
- The system assumes three user roles:
  - Customer
  - Operator
  - Administrator
- Only Operators can create concerts.
- Concerts are created in **Draft** status.
- Publish workflow is out of scope.
- Payment gateway integration is mocked.
- Payment is completed immediately after a successful mock payment.
- Booking expires automatically after **10 minutes** if payment is not completed.
- A booking can apply at most one voucher.
- Voucher supports both **Percentage** and **Fixed Amount** discounts.
- Partial payment is not supported.

## Booking Workflow

Booking supports four states:

- PendingPayment
- Confirmed
- Cancelled
- Expired

## Technical

- GUID is used as the primary key because it can be generated at the application layer and simplifies future distributed system evolution.
- For production systems with high write throughput, sequential GUIDs (`Guid.CreateVersion7()` or SQL Server `NEWSEQUENTIALID()`) are recommended to reduce index fragmentation.