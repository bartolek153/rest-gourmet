import EmployeeIcon from '@mui/icons-material/BadgeTwoTone';
import EmployeeList from "./EmployeeList";
import { EmployeeCreate, EmployeeEdit } from './EmployeeForm';

export default {
  list: EmployeeList,
  edit: EmployeeEdit,
  create: EmployeeCreate,
  icon: EmployeeIcon,
  link: '/employees',
};
