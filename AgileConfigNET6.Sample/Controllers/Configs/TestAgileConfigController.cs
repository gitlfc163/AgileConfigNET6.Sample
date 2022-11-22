
using AgileConfig.Client;
using AgileConfigNET6.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AgileConfigNET6.Sample.Controllers.Configs
{
    [ApiController]
    public class TestAgileConfigController : AreaController
    {
        private readonly ILogger<TestAgileConfigController> _logger;
        private readonly IConfiguration _config;
        private readonly IOptions<AppSetting> _appSetting;
        private readonly IConfigClient _IConfigClient;

        public TestAgileConfigController(IConfiguration config, IOptions<AppSetting> appSetting, IConfigClient configClient,ILogger<TestAgileConfigController> logger)
        {
            _config = config;
            _appSetting = appSetting;
            _IConfigClient = configClient;
            _logger = logger;
        }

        /// <summary>
        /// 使用IConfiguration读取配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByIConfiguration()
        {
            var RedisSetting = _config["AppSetting:RedisSetting:Connection"];

            return Ok(new { RedisSetting });
        }
        /// <summary>
        /// 使用Options模式读取配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByOptions()
        {
            var MysqlSetting = _appSetting.Value.MysqlSetting;

            return Ok(new { MysqlSetting });
        }
        /// <summary>
        /// 直接使用ConfigClient的实例读取配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByIConfigClient()
        {
            var RedisSetting = _IConfigClient["AppSetting:RedisSetting:Connection"];
            var MysqlSetting = _IConfigClient["AppSetting:MysqlSetting:Connection"];
            return Ok(new { RedisSetting,MysqlSetting });
        }
    }
}