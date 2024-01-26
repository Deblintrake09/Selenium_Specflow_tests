@userinterface
Feature: LoanApplication

As a loan application evaluator
I want to only approve loan requestes that meet the agreed upn loan amount rules
So the rist associated with suplying loans remains within regulatory limits



Scenario Outline: Loan amounts under 1000 are always approved
	Given John is an active ParaBank customer
	When they apply for <amount> loan
	Then the loan application is approved
	Examples:
	| amount |
	| 999    |
	| 1		 |

Scenario Outline: Loan amounts that are equal or greater to 100000 are always denied	Given John is an active ParaBank customer
	Given John is an active ParaBank customer
	When they apply for <amount> loan
	Then the loan application is denied
	Examples:
	| amount |
	| 100000 |
	| 999999 |

Scenario Outline: For loan amounts between 1000 and 100000 the result depends on the income
	Given John is an active ParaBank customer
	When they apply for <amount> loan
	And their monthly income is <income>
	Then the loan application is <result>
	Examples:
	| amount | income | result   |
	| 1000   | 3000   | approved |
	| 50000  | 3000   | denied   |
	| 99999  | 3000   | denied   |
	| 1000   | 2999   | denied   |
	| 50000  | 2999   | denied   |
	| 99999  | 2999   | denied   |

