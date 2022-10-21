export function buildCSVFromArray(values: string[][], separator: string): string {
    let csvContent: string = "";

    for (const row of values) {
        for (const cell of row) {
            csvContent += (cell + separator);
        }

        csvContent += '\n';
    }

    return csvContent;
}

export function downloadCSVContent(csvContent: string): void {
    let data = "data:text/csv;charset=utf-8," + encodeURIComponent(csvContent);

    let anchor = document.createElement("a");
    anchor.setAttribute("href", data);
    anchor.setAttribute("download", "translations.csv");
    
    document.body.appendChild(anchor); // required for firefox
    anchor.click();
    anchor.remove();
}

export function decodeCSVFile(csvFileContent: string, separator: string): string[][] {
    const base64data = csvFileContent.split(",")[1]; // Remove the 'data:text/csv;charset=utf-8,' part
    
    const hexaData = Array.prototype.map.call(
        atob(base64data),
        (c: string) => "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2) // get the hexa code of each character (f.i. '%26' for '&' or '%61' for 'a')
    ).join("");

    const plainTextData = decodeURIComponent(hexaData);
    return plainTextData.split("\n").map(row => row.split(separator));
}

export function convertColumnToLetter(columnIndex: number) {
    let columnAsLetters = "";
    const NUMBER_OF_LETTERS = 26;
    const FIRST_LETTER_CHAR_CODE = 65

    if (columnIndex === 0) return String.fromCharCode(FIRST_LETTER_CHAR_CODE);

    while (columnIndex > 0) {
      const nextLetterCode = (columnIndex % NUMBER_OF_LETTERS) + FIRST_LETTER_CHAR_CODE;
      columnAsLetters = String.fromCharCode(nextLetterCode) + columnAsLetters;
      columnIndex = Math.floor(columnIndex / 26);
    }

    return columnAsLetters;
}