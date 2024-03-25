using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class Products
    {
        public static class Conflicts
        {
            public static Error DuplicateProduct => Error.Conflict(
                code: "Product.DuplicateProduct",
                description: "Um produto com esta descrição já foi cadastrado.");

            public static Error DuplicateProductWithDescription(string description) => Error.Failure(
                code: "Product.DuplicateProduct",
                description: $"Um produto com a descrição '{description}' já foi criado.");

            public static Error FamilyWithCategory => Error.Conflict(
                code: "Product.Conflicts.FamilyWithCategory",
                description: "Não é possível excluir esta categoria pois existem famílias de produtos associadas a ela.");

            public static Error GroupWithFamily => Error.Conflict(
                code: "Product.Conflicts.GroupWithFamily",
                description: "Não é possível excluir esta família pois existem grupos de produtos associados a ela.");

            public static Error ProductWithGroup => Error.Conflict(
                code: "Product.Conflicts.ProductWithGroup",
                description: "Não é possível excluir este grupo pois existem produtos associados a ele.");

            public static Error WithInventoryParameters => Error.Conflict(
                code: "Product.Conflicts.ProductWithInventoryParameters",
                description: "Não é possível excluir este produto pois existem parâmetros de inventário associados a ele.");
        }
    }
}