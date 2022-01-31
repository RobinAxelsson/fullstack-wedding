export const langShift = (language, kurdVal, sweVal, engVal) =>
  language === 'kurdi'
    ? kurdVal
    : language === 'swe'
    ? sweVal
    : language === 'eng'
    ? engVal
    : null;