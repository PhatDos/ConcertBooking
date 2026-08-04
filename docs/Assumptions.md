# Assumptions

To keep the assignment focused on the core booking workflow, several assumptions are made.

## Authentication

Authentication and Authorization are out of scope.

Users are assumed to be authenticated by an external identity provider.

---

## User Roles

The system assumes three roles:

- Customer
- Operator
- Administrator

Role-based authorization is not implemented in this assignment.

---

## Concert

Concerts are created in Draft status.

Publishing concerts is not implemented.

---

## Booking

Booking supports four states:

- PendingPayment
- Confirmed
- Cancelled
- Expired

Bookings expire after 10 minutes.

---

## Voucher

One booking can apply at most one voucher.

Voucher supports

- Percentage
- Fixed Amount

---

## Payment

Payment gateway is mocked.

Payment is completed immediately.

Partial payment is not supported.