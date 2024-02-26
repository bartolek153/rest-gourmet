import { LoadingIndicator, ToggleThemeButton } from 'react-admin';

// import { ThemeSwapper } from '../themes/ThemeSwapper';

export const AppBarToolbar = () => (
    <>
        <ToggleThemeButton />
        {/* <LocalesMenuButton /> */}
        <LoadingIndicator />
    </>
);
