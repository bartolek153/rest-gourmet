import {
  ArrayInput,
  AutocompleteInput,
  BooleanInput,
  Edit,
  FormDataConsumer,
  ReferenceInput,
  SaveButton,
  SimpleForm,
  SimpleFormIterator,
  TextField,
  Toolbar,
} from "react-admin"
import { useParams } from 'react-router-dom';
import AddIcon from '@mui/icons-material/AddCircle';


const CustomToolbar = (props: any) => (
  <Toolbar {...props} >
    <SaveButton />
  </Toolbar>
);


const ReceiptProductMapping = () => {
  const { id } = useParams();
  //useform


  return (
    <Edit
      resource={`receipts/mapping`}
      title={`Vínculo de produtos #${id}`}
      mutationMode="pessimistic"
    >
      <SimpleForm toolbar={<CustomToolbar />} mode="onChange">
        <ArrayInput source="mappings" label="Produtos">
          <SimpleFormIterator
            inline fullWidth
            disableReordering
            disableAdd disableClear disableRemove
            sx={{
              [`& .RaSimpleFormIterator-form`]: {
                alignItems: 'center'
              },
            }}
          >
            <TextField
              source="partnerProductId"
              label="Produto do Fornecedor"
              sx={{ width: 150 }}
            />
            <TextField
              source="partnerProductDescription"
              label="Descrição"
              sx={{ width: 400 }}
            />

            <FormDataConsumer>
              {
                ({ getSource, scopedFormData }) => {
                  const createProduct = scopedFormData?.createProduct;
                  return (
                    <ReferenceInput source={getSource("inventoryProductId")} reference="products" perPage={30}>
                      <AutocompleteInput
                        optionText="description"
                        label="Produto de Estoque"
                        sx={{ width: 400 }}
                        disabled={createProduct}
                        helperText={false}
                      />
                    </ReferenceInput>
                  )
                }
              }
            </FormDataConsumer>

            <BooleanInput
              source="createProduct"
              label={false}
              helperText={false}
            />

            <FormDataConsumer>
              {
                ({ scopedFormData }) => {
                  const createProduct = scopedFormData?.createProduct;
                  return (
                    createProduct ? <AddIcon color="success" /> : null
                  )
                }
              }
            </FormDataConsumer>

          </SimpleFormIterator>
        </ArrayInput>
      </SimpleForm>
    </Edit>
  )
}

export default ReceiptProductMapping;
