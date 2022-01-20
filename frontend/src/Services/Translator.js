const baseTranslation = (lang, kurdVal, sweVal, engVal) =>
  lang === 'kurdi'
    ? kurdVal
    : lang === 'swe'
    ? sweVal
    : lang === 'eng'
    ? engVal
    : null;

export const title = (lang) =>
  baseTranslation(lang, 'bachi', 'test', 'Join our wedding!');
export const submit = (lang) =>
  baseTranslation(lang, 'afarin', 'test', 'Submit!');
export const relationPlaceHolder = (lang) =>
  baseTranslation(lang, 'afarin', 'relation', 'relation');
export const namePlaceHolder = (lang) =>
  baseTranslation(lang, 'nauwi', 'name', 'name');
