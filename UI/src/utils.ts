import XLSX from 'xlsx';

export const downloadXLSX = (data: any[], header: string[][], fileName: string) => {

    console.log('data', data);
    console.log('header', header);
    console.log('fileName', fileName);

    const wb = XLSX.utils.book_new();
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet([]);
    XLSX.utils.sheet_add_aoa(ws, header);
    XLSX.utils.sheet_add_json(ws, data, { origin: 'A2', skipHeader: true });
    XLSX.utils.book_append_sheet(wb, ws, 'Planilha');
    XLSX.writeFile(wb, fileName+'.xlsx');
}

export const formatPhoneNumber = (value: string) => {
  // accepted formats: +55 (11) 98888-8888 / 9999-9999 / 21 98888-8888 / 5511988888888

  if (!value) return "";
  value=value.replace(/\D/g,"");
  
  if (value.length == 11) value=value.replace(/^(\d{2})(\d)/g,"$1 $2");
  if (value.length > 5) value=value.replace(/(\d)(\d{3})$/,"$1-$2");
  return value;
}