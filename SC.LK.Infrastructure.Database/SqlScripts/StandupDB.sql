INSERT INTO scancitylkdb.roleentity (Id, FinanceRole, ChangingContractorProfile, CreatingChangingUserProfile, ChangingConfiguration, Updated) VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                                                                                      '1',
                                                                                                                                                      '1',
                                                                                                                                                      '1',
                                                                                                                                                      '1',
                                                                                                                                                      '2021-09-05 12:41:38.980305');
INSERT INTO scancitylkdb.keys (Id, PublicKey, PrivateKey, Updated) VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                           '1',
                                                                           '1',
                                                                           '2021-09-05 12:41:38.980305');

INSERT INTO scancitylkdb.paymentsystementity (Id, Name, Updated) VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                         'yandex',
                                                                         '2021-09-05 12:41:38.980305');

INSERT INTO scancitylkdb.billingfaces (Id, Name, INN, KPP, PaymentSystemId, Updated) VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                             'BF1',
                                                                                             '1',
                                                                                             '2',
                                                                                             '3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                             '2021-09-05 12:41:38.980305');

INSERT INTO scancitylkdb.contractors (Id, Name, UsersId, AccessAreasId, BillingFaceId, KeysId, Partner, PaymentSystem, Updated) VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                                                                                        'Магнит', 
                                                                                                                                        '3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                                                                                        '3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                                                                        '3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                                                                                        '3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                                                                        '1', 
                                                                                                                                        '1',
                                                                                                                                        '2021-09-05 12:41:38.980305');

INSERT INTO scancitylkdb.accessareas (Id, UserId, СontractorId, RolesId, AccessAreasId, Updated) VALUES  ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                                                         '3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                                                         '3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                                         '3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                                         '3fa85f64-5717-4562-b3fc-2c963f66afa6',
                                                                                                         '2021-09-05 12:41:38.980305');

INSERT INTO scancitylkdb.users (Id, ContractorId, UsersId, Updated) VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                            '3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                            '3fa85f64-5717-4562-b3fc-2c963f66afa6', 
                                                                            '2021-09-05 12:41:38.980305');