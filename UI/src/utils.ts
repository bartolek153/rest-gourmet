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
