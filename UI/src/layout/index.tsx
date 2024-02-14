import { Layout } from "react-admin";
import CustomNotification from "./Notification/CustomNotification";

const CustomLayout = (props: any) => <Layout {...props} />;

export default {
    layout: CustomLayout,
    notification: CustomNotification,
}
