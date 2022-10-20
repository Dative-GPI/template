export function swapElements<T>(array: T[], index1: number, index2: number): T[] {
    if (index1 < 0 || index1 >= array.length ||
        index2 < 0 || index2 >= array.length) return array;

    const refElement1 = array[index1];
    const refElement2 = array[index2];

    array[index1] = refElement2;
    array[index2] = refElement1;

    return array;
}