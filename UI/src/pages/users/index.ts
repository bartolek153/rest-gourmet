import UserIcon from '@mui/icons-material/AccountCircleTwoTone';
import UserList from "./UserList";
import { UserEdit, UserCreate } from "./UserForm";


export default {
  list: UserList,
  edit: UserEdit,
  create: UserCreate,
  icon: UserIcon,
  link: '/users',
};
