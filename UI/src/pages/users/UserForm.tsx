import {
  Create,
  Edit,
  DateInput,
  SimpleForm,
  TextInput,
  PasswordInput,
} from 'react-admin';
import { Box, Grid, Typography } from '@mui/material';

const UserForm = () => {
  return (
    <SimpleForm
      sx={{ maxWidth: 900 }}
    >
      <Grid container width="100%">
        <Grid item xs={8}>
          <SectionTitle label="Identificação" />

          <TextInput source="name" label="Nome" isRequired fullWidth />
          <TextInput source="cpf" label="CPF" fullWidth />

          <Box display="flex">
            <Box flex={1} mr="0.5em">
              <DateInput
                source="birthDate"
                label="Data de Nascimento"
                fullWidth
                helperText={false}
              />
            </Box>
            <Box flex={2} ml="0.5em" />
          </Box>

          <Separator />
          <SectionTitle label="Contato" />

          <Box display={{ xs: 'block', sm: 'flex' }}>
            <Box flex={1} mr={{ xs: 0, sm: '0.5em' }}>
              <TextInput type="email" source="email" label="E-mail" fullWidth isRequired />
            </Box>
            <Box flex={1} ml={{ xs: 0, sm: '0.5em' }}>
              <TextInput
                source="phoneNumber"
                label="Celular"
                // format={(num) => formatPhoneNumber(num)} 
                fullWidth
              />
            </Box>
          </Box>

          <Separator />
          <SectionTitle label="Segurança" />

          <Box display="flex" width="50%">
            <Box flex={1} mr="0.5em">
              <PasswordInput source="password" isRequired label="Senha" />
            </Box>
          </Box>
        </Grid>
      </Grid>
    </SimpleForm>
  );
};

const SectionTitle = ({ label }: { label: string }) => {
  return (
    <Typography variant="h6" gutterBottom>
      {label as string}
    </Typography>
  );
};

const Separator = () => <Box pt="1em" />;

export const UserEdit = (props: any) => (
  <Edit {...props} mutationMode="pessimistic">
    <UserForm />
  </Edit>
);

export const UserCreate = (props: any) => (
  <Create {...props}>
    <UserForm />
  </Create>
);
