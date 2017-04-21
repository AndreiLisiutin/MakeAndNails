/**
 * Класс для описания сообщений об ошибках.
 */
export class ErrorMessages {
	required: string;
	pattern: string;
	minLength: string;
	maxLength: string;

	rangeLength: string;
	min: string;
	gt: string;
	gte: string;
	max: string;
	lt: string;
	lte: string;
	range: string;
	digits: string;
	number: string;
	url: string;
	email: string;
	date: string;
	minDate: string;
	maxDate: string;
	dateISO: string;
	creditCard: string;
	json: string;
	base64: string;
	phone: string;
	uuid: string;
	equal: string;
	notEqual: string;
	equalTo: string;
	notEqualTo: string;
	unknownError: string;

	[key: string]: string;
}