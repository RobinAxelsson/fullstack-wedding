const baseTranslation = (lang, kurdVal, sweVal, engVal) =>
  lang === 'kurdi'
    ? kurdVal
    : lang === 'swe'
    ? sweVal
    : lang === 'eng'
    ? engVal
    : null;

export const titleText = (lang) =>
  baseTranslation(lang, 'Bexerben bo', 'Fira våran dag!', 'Join our wedding!');
export const submitBtnText = (lang) =>
  baseTranslation(lang, 'Bale', 'OSA', 'Submit!');
export const languageBtnText = (lang) =>
  baseTranslation(lang, 'Till Svenska', 'To English', 'Kurdi');
export const closestToText = (lang) =>
  baseTranslation(lang, 'Shan yan Robin?', 'Närmast?', 'Closest to?');
export const ageText = (lang) =>
  baseTranslation(lang, 'To ment chende?', 'Ålder', 'Age');
export const hobbiesText = (lang) =>
  baseTranslation(lang, 'Berdjewendi?', 'Intressen', 'Interests');
export const nameText = (lang) =>
  baseTranslation(lang, 'Nauwet chiya', 'Namn', 'Name');
export const relationText = (lang) =>
  baseTranslation(lang, 'Phiuhndi', 'Hur träffades ni?', 'How did you meet?');
