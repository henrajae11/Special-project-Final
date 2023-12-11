SELECT ticket.Tid, ticket.Fcode, ticket.Pid, ticket.PName, ticket.PPass,
		ticket.PNatation, ticket.Amt,
		ft.Fsrc, ft.FDest, ft.FDate, ft.FCap
	FROM TicketTbl ticket
Inner Join FlightTbl ft on ticket.Fcode = ft.Fcode
where ticket.PPass = 'AJ3666' 

