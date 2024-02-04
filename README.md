# Augusta Gourmet REST API

## Overview

## Usage

## Backend TODO

* Tools
  * Migrate from .NET Framework 4.6 to .NET Core 8 ✔️
  * Migrate from EF6 to EF Core ❌
  * Implement JWT ❌
* Code Refactor
  * Change database objects naming conventions ❌
  * Review database data types schemas (nullable, datetimes, inheritances, ...) ❌
  * Make use of database schemas ❌
  * Add tests ❌
  * Add company code in all tables (new BaseEntity prop.) ❌
  * Add enumerated types ❌
  * Implement auditable entities ❌
  * Substitute integer boolean values by bool type ❌
  * Multi-tenant environment (database, branches, ...) ❌
  * Add some method of storing configuration + credentials ❌
  * Add logging and messaging with Telegram/SMTP(?) ❌
  * Add database indexes with EF ❌
  * Add Unit of Work ❌
  * Add domain events ❌
  * Dynamic ordering and filtering ❌
  * Add caching ❌
* Business Rules
  * On receipt insert, update PartnerProduct descriptions according to the latest inserts
* Code Documentations
  * Generate API docs ❌
  * Generate code docs ❌
* CI/CD
  * Implement Azure/Github pipelines ❌
  * Tagging and versioning ❌
  * Dockerize ❌

## UI TODO

* On form error, show the error again after multiple clicks on save button (or use helperText) -> ReceiptProductsMapping.tsx
