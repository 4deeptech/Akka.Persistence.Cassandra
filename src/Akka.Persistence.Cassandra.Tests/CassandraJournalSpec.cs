using Akka.Configuration;
using Akka.Persistence.TestKit.Journal;

namespace Akka.Persistence.Cassandra.Tests
{
    public class CassandraJournalSpec : JournalSpec
    {
        //private static readonly Config JournalConfig = ConfigurationFactory.ParseString(@"
        //    akka.persistence.journal.plugin = ""cassandra-journal""
        //    akka.test.single-expect-default = 10s
        //");

        private static readonly Config JournalConfig = ConfigurationFactory.Load();

        public CassandraJournalSpec()
            : base(JournalConfig, "CassandraJournalSystem")
        {
            TestSetupHelpers.ResetJournalData(Sys);
            Initialize();
        }
        
        protected override void Dispose(bool disposing)
        {
            TestSetupHelpers.ResetJournalData(Sys);
            base.Dispose(disposing);
        }

        protected override bool SupportsRejectingNonSerializableObjects { get { return false; } }
    }
}
