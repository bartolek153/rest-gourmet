import { Layout, LayoutProps } from "react-admin";
import CustomAppBar from "./AppBar";
import CustomMenu from "./Menu";

export default (props: LayoutProps) => (
    <Layout {...props} appBar={CustomAppBar} menu={CustomMenu} />
);
