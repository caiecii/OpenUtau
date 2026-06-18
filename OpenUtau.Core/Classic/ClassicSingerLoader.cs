using System.Collections.Generic;
using System.Linq;
using OpenUtau.Core;
using OpenUtau.Core.Ustx;

namespace OpenUtau.Classic {
    public static class ClassicSingerLoader {
        static USinger AdjustSingerType(Voicebank v) {
            switch (v.SingerType) {
                default:
                    return new ClassicSinger(v) as USinger;
            }
        }
        public static IEnumerable<USinger> FindAllSingers() {
            List<USinger> singers = new List<USinger>();
            foreach (var path in PathManager.Inst.SingersPaths) {
                var loader = new VoicebankLoader(path);
                singers.AddRange(loader.SearchAll()
                    .Select(AdjustSingerType));
            }
            return singers;
        }
    }
}
