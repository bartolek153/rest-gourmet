import { Count, useStore } from "react-admin";
import { Box, Card, Typography, MenuList, MenuItem, ListItemText } from '@mui/material';

export const InvoiceStatusesAside = () => {
    const [statusFilter, setStatusFilter] = useStore("statusMenu", { status: 'open' });
    return (
        <Box width={200} mr={1} mt={7} flexShrink={0} order={-1}>
            <Card>
                <Typography variant="h6" m={2}>
                    Status
                </Typography>

                <MenuList>
                    <MenuItem
                        onClick={() => setStatusFilter({ status: 'open' })}
                    >
                        <ListItemText>Tudo</ListItemText>
                        <Count filter={{ status: 'open' }} />
                    </MenuItem>
                    <MenuItem
                        onClick={() => setStatusFilter({ status: 'pending' })}
                    >
                        <ListItemText>Pendentes</ListItemText>
                        <Count filter={{ status: 'pending' }} />
                    </MenuItem>
                    {/* <MenuItem
                        onClick={() => setStatusFilter({ status: 'closed' })}
                    >
                        <ListItemText>Closed</ListItemText>
                        <Count filter={{ status: 'closed' }} />
                    </MenuItem>
                    <MenuItem
                        onClick={() => setStatusFilter({ status: 'closed' })}
                    >
                        <ListItemText>All</ListItemText>
                        <Count filter={{}} />
                    </MenuItem> */}
                </MenuList>
            </Card>
        </Box>
    );
};
