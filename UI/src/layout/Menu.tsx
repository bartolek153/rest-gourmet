import * as React from 'react';
import { useState } from 'react';
import Box from '@mui/material/Box';
import LabelIcon from '@mui/icons-material/Label';

import {
    MenuItemLink,
    MenuProps,
    useSidebarState,
} from 'react-admin';

import products from '../pages/products';
import receipts from '../pages/receipts';

import SubMenu from './SubMenu';
import inventory from '../pages/inventory';
import suppliers from '../pages/suppliers';
import employeesAttendance from '../pages/employeesAttendance';
import employees from '../pages/employees';

type MenuName = 'menuProducts' | 'menuInventory';

const CustomMenu = ({ dense = false }: MenuProps) => {
    const [state, setState] = useState({
        menuProducts: false,
        menuInventory: false,
        menuEmployees: false,
    });

    const [open] = useSidebarState();

    const handleToggle = (menu: MenuName) => {
        setState(state => ({ ...state, [menu]: !state[menu] }));
    };

    return (
        <Box
            sx={{
                width: open ? 200 : 50,
                marginTop: 1,
                marginBottom: 1,
                transition: theme =>
                    theme.transitions.create('width', {
                        easing: theme.transitions.easing.sharp,
                        duration: theme.transitions.duration.leavingScreen,
                    }),
            }}
        >
            {/* <DashboardMenuItem /> */}

            <SubMenu
                handleToggle={() => handleToggle('menuProducts')}
                isOpen={state.menuProducts}
                name="Produtos"
                icon={<products.products.icon />}
                dense={dense}
            >
                <MenuItemLink
                    to={products.products.link}
                    state={{ _scrollToTop: true }}
                    primaryText={"Mercadorias"}
                    leftIcon={<products.products.icon />}
                    dense={dense}
                />

                <MenuItemLink
                    to={products.categories.link}
                    state={{ _scrollToTop: true }}
                    primaryText={"Categorias"}
                    leftIcon={<products.categories.icon />}
                    dense={dense}
                />
            </SubMenu>

            <MenuItemLink
                to={receipts.link}
                state={{ _scrollToTop: true }}
                primaryText={"Notas Fiscais"}
                leftIcon={<receipts.icon />}
                dense={dense}
            />

            <SubMenu
                handleToggle={() => handleToggle('menuInventory')}
                isOpen={state.menuInventory}
                name="Inventário"
                icon={<inventory.parameters.icon />}
                dense={dense}
            >
                <MenuItemLink
                    to={inventory.parameters.link}
                    state={{ _scrollToTop: true }}
                    primaryText={"Parâmetros"}
                    leftIcon={<inventory.parameters.icon />}
                    dense={dense}
                />
                <MenuItemLink
                    to={suppliers.link}
                    state={{ _scrollToTop: true }}
                    primaryText={"Forncedores"}
                    leftIcon={<suppliers.icon />}
                    dense={dense}
                />
            </SubMenu>

            <SubMenu
                handleToggle={() => handleToggle('menuEmployees')}
                isOpen={state.menuEmployees}
                name="Funcionários"
                icon={<employees.icon />}
                dense={dense}
            >
                <MenuItemLink
                    to={employeesAttendance.link}
                    state={{ _scrollToTop: true }}
                    primaryText={"Ponto"}
                    leftIcon={<employeesAttendance.icon />}
                    dense={dense}
                />
            </SubMenu>
        </Box>
    );
};

export default CustomMenu;