# Augusta Gourmet REST API

## Overview

## Usage

## TODO

* Tools
  * Migrate from .NET Framework 4.6 to .NET Core 8 ✔️
  * Migrate from EF6 to EF Core ✔️
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
  * Add Multi-environment development + production (database, branches, ...) ✔️
  * Add some method of storing configuration + credentials ✔️
  * Add logging and messaging with Telegram ✔️
  * Add database indexes with EF ❌
  * Add Unit of Work ✔️
  * Add domain events ❌
  * Dynamic ordering ❌
  * Dynamic filtering ✔️
  * Add caching ❌
  * Implement Polly (error handling policy lib) ❌
  * Decouple email reader/sender to be server agnostic ❌
  * Implement Cancellation tokens ❌
  * Query necessary fields only ❌
  * Parametrize data and options ❌
  * Add multiple inheritance for paged queries (IRequest `<T>,`IPagedQuery)
* Business Rules
* Code Documentations
  * Generate API docs ❌
* CI/CD
  * Implement Github Actions pipelines ✔️
  * Use tagging ❌
  * Dockerize ❌

## Known errors

* On form error, show the error again after multiple clicks on save button (or use helperText) -> ReceiptProductsMapping.tsx
