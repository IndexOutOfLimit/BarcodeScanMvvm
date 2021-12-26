using BarCodeScanner.Repository.Contracts;
using BarCodeScanner.Repository.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCodeScanner.Repository
{
    public class BarCodeRepository : GenericRepository<BarCodeData, int>, IBarCodeRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public BarCodeRepository(SQLiteAsyncConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<List<BarCodeData>> DeleteBarCodes(List<string> barCodes)
        {
            try
            {
                var allBarCodes = await GetBarCodes();
                var selectedBarCodes = allBarCodes.Where(item1 =>
                                        barCodes.Any(item2 => item1.BarCodeValue.Equals(item2))).ToList();

                foreach (var item in selectedBarCodes)
                {
                    await _connection.DeleteAsync(item);
                }

                allBarCodes = await GetBarCodes();

                return allBarCodes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<List<BarCodeData>> GetBarCodes()
        {
            try
            {
                var allBarCodeRecords = _connection.Table<BarCodeData>();
                var barCodes = allBarCodeRecords.ToListAsync();

                return barCodes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }            
        }

        public async Task<List<BarCodeData>> SaveBarCode(string barCodeValue)
        {
            try
            {
                var barCodes = await GetBarCodes();
                if (barCodes.Any(l=>l.BarCodeValue.Equals(barCodeValue)))
                {
                    return barCodes;
                }
                BarCodeData barCodeData = new BarCodeData { BarCodeValue = barCodeValue };
                var allBarCodeRecords = await _connection.InsertAsync(barCodeData);

                barCodes = await GetBarCodes();

                return barCodes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
