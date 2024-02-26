import {
    List,
    Datagrid,
    TextField,
    NumberField,
    TextInput,
} from "react-admin";

const productFilters = [
    <TextInput source="q" label="Descrição" alwaysOn />,
];

const ProductCategoryList = () => (
    <List filters={productFilters} sort={{ field: 'description', order: 'ASC' }}>
        <Datagrid> //rowClick="edit"
            <NumberField source="id" />
            <TextField source="description" label="Descrição" />
        </Datagrid>
    </List>
);

export default ProductCategoryList;
