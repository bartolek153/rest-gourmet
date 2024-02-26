import ProductIcon from '@mui/icons-material/LocalGroceryStoreTwoTone';
import ProductList from "./ProductList";
import { ProductEdit, ProductCreate } from "./ProductForm";

export default {
  list: ProductList,
  edit: ProductEdit,
  create: ProductCreate,
  icon: ProductIcon,
  link: '/products',
};
