INSERT INTO `isaprojekat`.`users` (`Id`, `Email`, `Password`, `Role`, `FirstName`, `LastName`, `City`, `Country`, `Phone`, `Occupation`, `Workplace`, `Status`, `PenaltyPoints`) VALUES ('1', 'asd@asd.com', 'asd', '0', 'asd', 'asdic', 'ns', 'rs', '0022020', 'asd', 'asd', '1', '0');
INSERT INTO `isaprojekat`.`users` (`Id`, `Email`, `Password`, `Role`, `FirstName`, `LastName`, `City`, `Country`, `Phone`, `Occupation`, `Workplace`, `Status`, `PenaltyPoints`) VALUES ('2', 'qwe@qwe.com', 'qwe', '1', 'qwe', 'qweic', 'ns', 'rs', '224623624', 'ad', 'qw', '1', '0');
INSERT INTO `isaprojekat`.`users` (`Id`, `Email`, `Password`, `Role`, `FirstName`, `LastName`, `City`, `Country`, `Phone`, `Occupation`, `Workplace`, `Status`, `PenaltyPoints`) VALUES ('3', 'yxc@yxc.com', 'yxc', '2', 'yxc', 'yxcic', 'bg', 'rs', '099099', 'sdf', 'sdf', '1', '0');

INSERT INTO `isaprojekat`.`companies` (`Id`, `Name`, `Address`, `Description`, `Rating`) VALUES ('1', 'MediShop', 'Svetosavska 22', 'Naša prodavnica ima tradiciju dugu 500 godina', '4.67');

INSERT INTO `isaprojekat`.`appointments` (`Id`, `Start`, `Duration`, `HandledBy`, `CompanyId`) VALUES ('1', '2024-02-02 18:00:00', '10', '2', '1');
INSERT INTO `isaprojekat`.`appointments` (`Id`, `Start`, `Duration`, `HandledBy`, `CompanyId`) VALUES ('2', '2024-02-03 12:00:00', '15', '2', '1');

INSERT INTO `isaprojekat`.`manages` (`Id`, `CompanyId`, `CompAdminId`) VALUES ('1', '1', '2');

INSERT INTO `isaprojekat`.`complaints` (`Id`, `Subject`, `Description`, `UserId`, `ComplaintObject`) VALUES ('1', 'Prljava čekaonica', 'Nešto se oseti u hodniku dobro nisam umrela bouže', '3', '1');

INSERT INTO `isaprojekat`.`products` (`Id`, `Name`, `Description`, `Price`) VALUES ('1', 'Špricevi kutija 10 pack', 'Pakovanje kutije sa špricevima koji sadrže 10 komada', '1500.99');
INSERT INTO `isaprojekat`.`products` (`Id`, `Name`, `Description`, `Price`) VALUES ('2', 'RTG makina', 'Mašina za rentgen, ili rendgen, ili rengen, rontgen, ili kako god želite da je napišete, dokle god nam date pare nama svejedno', '200000');

INSERT INTO `isaprojekat`.`offers` (`Id`, `CompanyId`, `ProductId`) VALUES ('1', '1', '1');
INSERT INTO `isaprojekat`.`offers` (`Id`, `CompanyId`, `ProductId`) VALUES ('2', '1', '2');

INSERT INTO `isaprojekat`.`reservations` (`Id`, `ProductId`, `AppointmentId`, `ReservedBy`, `TimeReserved`) VALUES ('1', '1', '1', '3', '2024-02-01 11:00');
