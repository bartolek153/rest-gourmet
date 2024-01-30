import { ReferenceInput, SelectInput } from "react-admin";

interface ReferenceInputWrapperProps {
  source: string;
  reference: string;
  label?: string;
  optionTextField: string;
  filter?: any;
}

export const ReferenceInputWrapper = (props: ReferenceInputWrapperProps) => {
  const {
    source,
    reference,
    label = undefined,
    optionTextField,
    // filter = undefined,
  } = props;
  return (
    <ReferenceInput source={source} reference={reference}>
      <SelectInput optionText={optionTextField} label={label} value={""} />
    </ReferenceInput>
  );
};
