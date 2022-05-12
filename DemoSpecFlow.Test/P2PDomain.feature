Feature: P2PDomain

Simple example of a feature for a given Domain

@P2PException.Invalid.amount
Scenario: Reject P2P if Amount is negative
	Given the following p2p payload:
	| Sender   | Receiver | Amount |
	| Wilfried | Fred     | -7     |
	And the following userId Wilfried
	When creating P2P
	Then the following exception should be thrown
	| Type                        | Message        |
	| System.ApplicationException | Invalid amount |

