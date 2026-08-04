# Limitations

The project focuses on demonstrating backend architecture and business workflow rather than building a production-ready system.

The following features are intentionally out of scope.

---

## Authentication

- Login
- JWT Authentication
- Authorization

---

## Concert Management

- Publish / Unpublish Concert
- Delete Concert
- Update Concert

---

## Voucher

The current implementation only supports voucher creation and redemption.

The following features are not implemented:

- Update Voucher
- Delete Voucher
- Per-user voucher limit
- Voucher redemption history

---

## Booking

Automatic booking expiration is not implemented.

Background jobs are not implemented.

Reserved tickets are not automatically released after expiration.

---

## Audit Trail

Booking status history is not implemented.

Operator actions are not audited.

---

## Payment

Third-party payment gateway

Payment callback

Refund

Retry payment

---

## Flash Sale

The current implementation demonstrates the reservation workflow.

Production-scale optimization (distributed cache, message queue, distributed locking) is not implemented.