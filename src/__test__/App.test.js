import { render, screen } from '@testing-library/react';
import GuestForm from '../components/GuestForm';

test('renders Guest Form title english', () => {
  render(<GuestForm language={"eng"}/>);
  const linkElement = screen.getByText(/Join our Wedding/i);
  expect(linkElement).toBeInTheDocument();
});
test('renders Guest Form title kurdi', () => {
  render(<GuestForm language={"kurdi"}/>);
  const linkElement = screen.getByText(/Bexerben bo/i);
  expect(linkElement).toBeInTheDocument();
});
test('renders Guest Form svenska', () => {
  render(<GuestForm language={"swe"}/>);
  const linkElement = screen.getByText(/Fira våran dag!/i);
  expect(linkElement).toBeInTheDocument();
});
