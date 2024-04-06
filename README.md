# Augusta Gourmet REST API

## Overview

## Usage

### Starting REST API

```bash
dotnet run --project AugustaGourmet.Api.WebAPI
```

### Starting UI

```bash
cd UI
yarn
yarn dev
```

## TODO

* Refactor Pendings
  * Migrate from .NET Framework 4.6 to .NET Core 8 ✔️
  * Migrate from EF6 to EF Core ✔️
  * Implement IDateTimeProvider ❌
  * Implement JWT ❌
  * Change database objects naming conventions ❌
  * Review db data types (nullable, datetimes, inheritances, ...) ❌
  * Make use of db schemas ❌
  * Add tests ❌
  * Add company code in all tables (new BaseEntity prop.) ❌
  * Add enumerated types ✔️
  * Implement auditable entities ❌
  * Substitute integer boolean values by bool type ❌
  * Add multi-environment development + production (database, branches, ...) ✔️
  * Implement multi-tenancy (rows per company) ❌
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
  * Implement cancellation tokens ❌
  * Query necessary fields only ❌
  * Parametrize data and options ❌
  * Add multiple inheritance for paged queries (IRequest `<T>,`IPagedQuery)
  * Implement UI Tree Layout ([https://marmelab.com/react-admin-demo/#/invoices](https://marmelab.com/react-admin-demo/#/invoices)) ❌
  * Implement UI Side Detail Layout ([https://marmelab.com/react-admin-demo/#/reviews/80](https://marmelab.com/react-admin-demo/#/reviews/80)) ❌
  * Implement UI Flex Form Layouts ([https://marmelab.com/react-admin-demo/#/customers/26](https://marmelab.com/react-admin-demo/#/customers/26)) ❌
  * Implement UI Dialog ([https://marmelab.com/blog/2018/08/27/react-admin-tutorials-custom-forms-related-records.html](https://marmelab.com/blog/2018/08/27/react-admin-tutorials-custom-forms-related-records.html))
  * Add color markup on sidebar menu current screen/location ❌
  * Add client-side valiation ❌
  * Generate API docs ❌
  * Implement Github Actions pipelines ✔️
  * Add dependabot ❌
  * Use tagging ❌
  * Dockerize ❌
  * Update React-Admin to v5

## Known errors

* UI
* ReceiptProductsMapping.tsx -> on form error, it doesn't allow sending a request again
