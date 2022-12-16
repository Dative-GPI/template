import { subDays, addMinutes, format, startOfISOWeek, startOfMonth, startOfYear, parse, isAfter } from "date-fns";
import frLocale from "date-fns/locale/fr";

const FrDateFormat = "EEE dd LLL yyyy";
const IsoDateFormat = "yyyy-MM-dd";
const FrTimeFormat = "EEE dd LLL yyyy HH:mm:ss";
const IsoTimeFormat = "yyyy-MM-dd'T'HH:mm:ss";

export const DateTools =  {
  formatDate: (date: Date): string => {
    try { return format(date, FrDateFormat, { locale: frLocale }); }
    catch { return ""; }
  },
  formatISODate: (date: Date): string => {
    try { return format(date, IsoDateFormat, { locale: frLocale }); }
    catch { return ""; }
  },
  parseDate: (date: string): Date => parse(date, IsoDateFormat, new Date(), { locale: frLocale }),
  formatTime: (date: Date): string => {
    try { return format(date, FrTimeFormat, { locale: frLocale }) }
    catch { return ""; }
  },
  formatISOTime: (date: Date): string => {
    try { return format(date, IsoTimeFormat, { locale: frLocale }); }
    catch { return ""; }
  },
  parseTime: (date: string): Date => parse(date, IsoTimeFormat, new Date(), { locale: frLocale }),
  startOfWeek: (date: Date): Date => startOfISOWeek(date),
  startOfMonth: (date: Date): Date => startOfMonth(date),
  startOfYear: (date: Date): Date => startOfYear(date),
  subDays: (date: Date, days: number): Date => subDays(date, days),
  addMinutes: (date: Date, minutes: number): Date => addMinutes(date, minutes),
  isAfter: (dateA: Date, dateB: Date): boolean => isAfter(dateA, dateB),
  doubleToHours: (hours: number): string => {
    const minutes = Math.floor(hours % 1 * 60);
    return Math.floor(hours) +  "h " + (minutes > 0 ? `${minutes}m` : '');   
  }
}