import { AutocompleteInput, Create, Edit, NumberInput, ReferenceInput, SelectInput, SimpleForm, TextInput } from "react-admin";
import { Box, Typography } from "@mui/material";

const ProductForm = () => {
  return (
    <SimpleForm>
      <Typography variant="h5" gutterBottom>
        <Box sx={{ fontWeight: "bold" }}>Cadastro de Produto</Box>
      </Typography>

      <Box display={{ xs: "block", sm: "flex", width: "80%" }}>
        <Box flex={1} mr={{ xs: 0, sm: "0.5em" }}>
          <TextInput
            source="description"
            label="Descrição"
            isRequired
            fullWidth
          />
        </Box>

        <ReferenceInput source="groupId" reference="products/groups" perPage={30}>
          <AutocompleteInput
            optionText="description"
            label="Grupo"
            sx={{ width: 300 }}
          />
        </ReferenceInput>

        <Box flex={1} ml={{ xs: 0, sm: "0.5em" }}>
          <ReferenceInput source="companyId" reference="products/companies" perPage={30}>
            <SelectInput
              optionText="name"
              label="Empresa"
              sx={{ width: 300 }}
            />
          </ReferenceInput>
        </Box>
      </Box>

      <Separator />

      <Typography variant="h6" gutterBottom>
        Aquisição
      </Typography>

      <Box display={{ xs: "block", sm: "flex" }}>
        <Box flex={1} mr={{ xs: 0, sm: "0.5em" }}>
          <NumberInput source="purchasePrice" label="Preço de Compra" />
          <ReferenceInput source="originId" reference="products/origins" perPage={30}>
            <SelectInput
              optionText="description"
              label="Procedência"
              sx={{ width: 300 }}
            />
          </ReferenceInput>
        </Box>

        <Box flex={2}>
          <ReferenceInput source="purchaseUnitId" reference="units" perPage={30}>
            <AutocompleteInput
              optionText="description"
              label="Unidade de compra"
              sx={{ width: 300 }}
            />
          </ReferenceInput>
        </Box>
      </Box>

      <Separator />

      <Typography variant="h6" gutterBottom>
        Armazenamento
      </Typography>

      <Box display={{ xs: "block", sm: "flex" }}>
        <Box flex={1} mr={{ xs: 0, sm: "0.5em" }}>
          <SelectInput source="productUnitId" label="Unidade base" choices={[
            { id: 1, name: 'Kg' },
            { id: 2, name: 'L' },
            { id: 3, name: 'm' },
            { id: 4, name: 'Unid.' },
          ]} />
        </Box>
        <Box flex={1} ml={{ xs: 0, sm: "0.5em" }}>
          <SelectInput source="statusId" choices={[
            { id: 1, name: 'ATIVO' },
            { id: 2, name: 'BLOQUEADO' },
          ]} />
        </Box>
      </Box>
    </SimpleForm>
  );
};

const Separator = () => <Box pt="1em" />;

export const ProductEdit = (props: any) => (
  <Edit {...props} mutationMode="pessimistic">
    <ProductForm />
  </Edit>
);

export const ProductCreate = (props: any) => (
  <Create {...props}>
    <ProductForm />
  </Create>
);
