import { NumberField } from "react-admin";

interface MoneyFieldProps {
    source: string;
    label?: string;
    currency?: string;
}

export const MoneyField = (props: MoneyFieldProps) => {
    const { source, label, currency } = props;

    return <NumberField
        source={source}
        label={label}
        options={{ style: "currency", currency: currency || "BRL" }}
    />;
}
